#!/usr/bin/perl

use strict;
use warnings;

print "Content-type: application/json\n\n";

my %params;

# Parse query string (GET or POST with query params)
if ($ENV{'QUERY_STRING'}) {
    foreach my $pair (split(/&/, $ENV{'QUERY_STRING'})) {
        my ($key, $value) = split(/=/, $pair);
        $key =~ s/%([0-9A-Fa-f]{2})/chr(hex($1))/eg;
        $value =~ s/%([0-9A-Fa-f]{2})/chr(hex($1))/eg;
        $params{$key} = $value;
    }
}

# Parse POST body data
if ($ENV{'REQUEST_METHOD'} eq 'POST' && $ENV{'CONTENT_LENGTH'}) {
    my $input;
    read(STDIN, $input, $ENV{'CONTENT_LENGTH'});
    foreach my $pair (split(/&/, $input)) {
        my ($key, $value) = split(/=/, $pair);
        $key =~ s/%([0-9A-Fa-f]{2})/chr(hex($1))/eg;
        $value =~ s/%([0-9A-Fa-f]{2})/chr(hex($1))/eg;
        $params{$key} = $value;
    }
}

my $key = $params{'key'};
my $value = $params{'value'};

if (!$key || !defined $value) {
    print "Status: 400 Bad Request\n";
    print '{"error":"Missing key or value"}';
    exit 1;
}

my $output = `sudo /home/lgsm/blazor_lgsm/update_startup_parameters.sh '$key' '$value'`;
my $exit_code = $? >> 8;

if ($exit_code != 0) {
    print "Status: 400 Bad Request\n";
    print '{"error":"Failed to update parameter"}';
    exit $exit_code;
}

print '{"success":"Parameter updated successfully"}';
exit 0;
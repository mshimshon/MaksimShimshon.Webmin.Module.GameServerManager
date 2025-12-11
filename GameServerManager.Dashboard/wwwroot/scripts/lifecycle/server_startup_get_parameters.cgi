#!/usr/bin/perl

use strict;
use warnings;

print "Content-type: application/json\n\n";

my $output = `sudo /home/lgsm/blazor_lgsm/get_startup_parameters.sh`;
my $exit_code = $? >> 8;

if ($exit_code != 0) {
    print '{"error":"Failed to get startup parameters"}';
    exit $exit_code;
}

print $output;
exit 0;
#!/usr/bin/perl
use WebminCore;
use JSON::PP;

# Try to initialize - if session expired, Webmin redirects automatically
# But we want to catch that and return JSON instead
$ENV{'MINISERV_INTERNAL'} = 1;  # Prevent automatic redirects

my $authenticated = 0;
my $status_code = 200;

eval {
    init_config();
    if ($remote_user) {
        $authenticated = 1;
    } else {
        $status_code = 401;
    }
};

if ($@) {
    $status_code = 401;
}

# Always return JSON, never redirect
if ($status_code == 401) {
    print "Status: 401 Unauthorized\r\n";
}

print "Content-type: application/json\r\n";
print "Cache-Control: no-cache, no-store, must-revalidate\r\n";
print "\r\n";

my %data = (
    authenticated => $authenticated ? JSON::PP::true : JSON::PP::false,
    session_id => $main::session_id || '',
    user => $remote_user || '',
    timestamp => time(),
);

print JSON::PP->new->encode(\%data);
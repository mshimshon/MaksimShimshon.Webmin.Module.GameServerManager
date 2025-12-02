#!/usr/bin/perl

# Log the request
use WebminCore;
init_config();

ui_print_header(undef, "Blazor LGSM", "", undef, 1, 1);

# Force client-side redirect (Webmin theme blocks HTTP redirects)
print "Content-type: text/html\r\n";
print "\r\n";
print <<'EOF';
<!DOCTYPE html>
<html>
<head>
    <script>
        // Break out of any AJAX/iframe loading and force full page redirect
        (function() {
            var target = '/blazor_lgsm/app.cgi';
            if (window.top !== window.self) {
                window.top.location.replace(target);
            } else {
                window.location.replace(target);
            }
        })();
    </script>
    <meta http-equiv="refresh" content="0;url=/blazor_lgsm/app.cgi">
</head>
<body>Redirecting...</body>
</html>
EOF


#!/usr/bin/perl
use WebminCore;
init_config();

print "Content-type: text/html\n\n";
print <<'EOF';
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Blazor LGSM</title>
    <style>
        * { 
            margin: 0; 
            padding: 0; 
            box-sizing: border-box; 
        }
        html, body { 
            width: 100%; 
            height: 100%; 
            overflow: hidden; 
        }
        #blazor-iframe { 
            width: 100%; 
            height: 100%; 
            border: none; 
            display: block; 
        }
    </style>
</head>
<body>
    <iframe id="blazor-iframe" src="/blazor_lgsm/wwwroot/"></iframe>
</body>
</html>
EOF
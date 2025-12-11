#!/usr/bin/perl

# Called after module installation
sub module_install
{
    my $module_root = $ENV{'WEBMIN_MODULE_DIR'} || "/usr/share/webmin/blazor_lgsm";
    
    # Fix permissions on all .cgi files recursively
    system("find '$module_root' -name '*.cgi' -exec chmod 755 {} \\;");
    
    # Fix permissions on wwwroot
    system("chmod -R 755 '$module_root/wwwroot'");
}

1;
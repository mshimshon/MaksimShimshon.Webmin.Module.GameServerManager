BEGIN { push(@INC, ".."); };
use WebminCore;

init_config();

ui_print_header(undef, "Game Server Manager", "", undef, 1, 1);

print <<'END';
<iframe src="/blazor_lgsm/wwwroot/index.html?base=blazor_lgsm/wwwroot/"
        style="width:100%;height:100vh;border:none;"></iframe>
END

ui_print_footer("/", $text{'index'});
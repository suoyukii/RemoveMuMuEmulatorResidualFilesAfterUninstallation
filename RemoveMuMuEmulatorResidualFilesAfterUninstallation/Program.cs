using Microsoft.Win32;

// AppData\Roaming
var appdata_path = Environment.GetEnvironmentVariable("appdata") + @"\Netease";
var mumu_game_path = appdata_path + @"\MuMuGame";
if (Directory.Exists(mumu_game_path)) Directory.Delete(mumu_game_path, true);
var mumu_player_path = appdata_path + @"\MuMuPlayer";
if (Directory.Exists(mumu_player_path)) Directory.Delete(mumu_player_path, true);
if (Directory.Exists(appdata_path))
{
    if (Directory.GetFiles(appdata_path).Length == 0 && Directory.GetDirectories(appdata_path).Length == 0)
    {
        Directory.Delete(appdata_path, true);
    }
}

// AppData\Local
var local_appdata_path = Environment.GetEnvironmentVariable("localappdata");
mumu_player_path = local_appdata_path + @"\MuMuPlayer";
if (Directory.Exists(mumu_player_path)) Directory.Delete(mumu_player_path, true);
// AppData\Local\CrashRpt\UnsentCrashReports
var unsent_crash_reports = local_appdata_path + @"\CrashRpt\UnsentCrashReports";
foreach (var di in new DirectoryInfo(unsent_crash_reports).GetDirectories("MuMu*"))
{
    di.Delete(true);
}

// Users\Public\Documents\MuMu Files
const string mumu_files_path = @"C:\Users\Public\Documents\MuMu Files";
if (Directory.Exists(mumu_files_path)) Directory.Delete(mumu_files_path, true);

// Users\{user}\mumu_boot.txt
var home_path = Environment.GetEnvironmentVariable("homepath");
if (home_path.StartsWith($@"\")) home_path = Environment.GetEnvironmentVariable("systemdrive") + home_path;
var mumu_boot = home_path + @"\mumu_boot.txt";
if (File.Exists(mumu_boot)) File.Delete(mumu_boot);
// Users\{user}\.NEUM
var neum_path = home_path + @"\.NEUM";
if (Directory.Exists(neum_path)) Directory.Delete(neum_path, true);

// Users\Public\.MUMUVMM
var mumuvmm_path = @"C:\Users\Public\.MUMUVMM";
if (Directory.Exists(mumuvmm_path)) Directory.Delete(mumuvmm_path, true);
// Users\Default\.MUMUVMM
mumuvmm_path = @"C:\Users\Default\.MUMUVMM";
if (Directory.Exists(mumuvmm_path)) Directory.Delete(mumuvmm_path, true);
// Users\{user}\.MUMUVMM
mumuvmm_path = home_path + @"\.MUMUVMM";
if (Directory.Exists(mumuvmm_path)) Directory.Delete(mumuvmm_path, true);
// ProgramData\.MUMUVMM
mumuvmm_path = Environment.GetEnvironmentVariable("programdata") + @"\.MUMUVMM";
if (Directory.Exists(mumuvmm_path)) Directory.Delete(mumuvmm_path, true);

// C:\Program Files
var programfiles_path = Environment.GetEnvironmentVariable("programfiles") + @"\MuMuVMMVbox";
if (Directory.Exists(programfiles_path)) Directory.Delete(programfiles_path, true);

// C:\Program Files(x86)
var programfiles_x86 = Environment.GetEnvironmentVariable("programfiles(x86)") + @"\MuMuVbox";
if (Directory.Exists(programfiles_x86))
{
    try
    {
        Directory.Delete(programfiles_x86, true);
    }
    catch
    {
        // Register
        // HKEY_CURRENT_USER\Software\Nemu
        var reg_key = Registry.CurrentUser.CreateSubKey("Software");
        var has_nemu_reg = reg_key.GetSubKeyNames().Contains("Nemu");
        if (has_nemu_reg) reg_key.DeleteSubKey("Nemu");
        // HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\NeumDrv
        reg_key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\ControlSet001\Services");
        var has_nemu_drv_reg = reg_key.GetSubKeyNames().Contains("NeumDrv");
        if (has_nemu_drv_reg) reg_key.DeleteSubKey("NeumDrv");
        reg_key.Close();
        Console.WriteLine("Restart your computer and run this program again");
    }
}
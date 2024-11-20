using System.Globalization;

namespace RemoveMuMuEmulatorResidualFilesAfterUninstallation;

public static class Language
{
    public static string[] Get()
    {
        return CultureInfo.CurrentUICulture.Name switch
        {
            "zh-CN" =>
            [
                "清除卸载 MuMu 模拟器后的残留文件",
                "清除中...",
                "请重新启动计算机并再次运行此程序",
                "清除结束，这个窗口可以关闭了"
            ],
            _ =>
            [
                "Remove MuMu Emulator Residual Files After Uninstallation",
                "Removing...",
                "Please restart your computer and run this program again.",
                "Remove is complete, the window can be closed."
            ]
        };
    }
}
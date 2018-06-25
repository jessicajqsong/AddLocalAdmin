Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement

Module AddLCLAdmin

    Public localComp As String = System.Environment.MachineName

    Sub Main(ByVal args() As String)
        Dim GrpName As String = args(0)

        Try
            Dim localMachine As New DirectoryEntry("WinNT://" & localComp & ",computer")
            Dim AdminGrp As DirectoryEntry = localMachine.Children.Find("Administrators", "group")

            AdminGrp.Invoke("Add", New Object() {"WinNT://DOMAINNAME/" & GrpName})
            AdminGrp.CommitChanges()

            localMachine.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Module

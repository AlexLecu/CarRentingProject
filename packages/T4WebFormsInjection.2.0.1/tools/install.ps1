param($installPath, $toolsPath, $package, $project)

$project.ProjectItems.Item("T4WebFormsInjection.tt").Properties.Item("BuildAction").Value = 0 #prjBuildActionNone
$project.ProjectItems.Item("T4WebFormsInjection.tt.settings.xml").Properties.Item("BuildAction").Value = 0
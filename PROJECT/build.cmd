
IF EXIST .\artifacts (
	IF EXIST .\PROJECT (
		IF EXIST artifacts\Debug\bootstrap\net46\MSBuild\15.0\Bin\MSBuild.exe (
			for /F %%x in ('dir  /s /b .\PROJECT\*.sln') do (
				echo "====================Building %%x========================="
				call "artifacts\Debug\bootstrap\net46\MSBuild\15.0\Bin\MSBuild.exe" %%x
			)
		)
	) ELSE (
		mkdir PROJECT
		echo "A PROJECT folder is created."
	)
) ELSE (
	echo "Building MSBuild..."
	call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat"
    call build.cmd
)
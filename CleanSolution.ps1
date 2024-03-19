
# Remove all obj/bin folders with build output
Get-ChildItem -Recurse -Include @('obj','bin') -Directory | Remove-Item -Recurse -Force
# Remove all Paket related files
Get-ChildItem -Recurse -Include @('packages','paket-files') -Directory | Remove-Item -Recurse -Force
# Remove all VS files
Get-ChildItem -Recurse -Include @('.vs') | Remove-Item -Recurse -Force
Get-ChildItem -Recurse -Include @('*.user') | Remove-Item -Recurse -Force


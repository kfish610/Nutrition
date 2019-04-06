@echo off

rmdir "C:\Users\kfish\Documents\RimWorldModded\Mods\Nutrition" /s /q
xcopy "C:\Users\kfish\Documents\RimworldModding\Nutrition" "C:\Users\kfish\Documents\RimWorldModded\Mods\Nutrition" /i /s /e /exclude:C:\Users\kfish\Documents\RimworldModding\Nutrition\build\exclude.txt
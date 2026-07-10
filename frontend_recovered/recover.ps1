$transcriptPath = "C:\Users\Taha SÄ°NGÄ°N\.gemini\antigravity\brain\2d7e92df-a8e4-45ec-9a24-0f68f5fb0003\.system_generated\logs\transcript_full.jsonl"
$outputDir = "C:\Users\Public\lojistikyol\frontend_recovered"

if (!(Test-Path $outputDir)) {
    New-Item -ItemType Directory -Path $outputDir -Force
}

Get-Content -Path $transcriptPath | ForEach-Object {
    try {
        $step = $_ | ConvertFrom-Json -ErrorAction SilentlyContinue
        if ($step -eq $null) { return }
        
        # Check tool calls
        if ($step.tool_calls) {
            foreach ($tc in $step.tool_calls) {
                $name = $tc.name
                $args = $tc.args
                
                # If args is a string, parse it
                if ($args -is [string]) {
                    $args = $args | ConvertFrom-Json -ErrorAction SilentlyContinue
                }
                if ($args -eq $null) { continue }
                
                if ($name -eq "write_to_file") {
                    $target = $args.TargetFile
                    $content = $args.CodeContent
                    if ($target -and $content) {
                        $filename = [System.IO.Path]::GetFileName($target)
                        $outPath = Join-Path $outputDir $filename
                        [System.IO.File]::WriteAllText($outPath, $content)
                        Write-Host "Recovered from write_to_file: $filename"
                    }
                }
            }
        }
        
        # Check view_file output in content
        if ($step.type -eq "PLANNER_RESPONSE" -and $step.status -eq "DONE" -and $step.content) {
            $content = $step.content
            if ($content -like "*File Path: *") {
                # Try to extract file path using single-quoted regex literals
                if ($content -match 'File Path: `file:///(.*?)`' -or $content -match 'File Path: `(.*?)`') {
                    $rawPath = $Matches[1]
                    $rawPath = $rawPath.Replace("%20", " ")
                    $filename = [System.IO.Path]::GetFileName($rawPath)
                    
                    # Extract lines
                    $lines = @()
                    $contentLines = $content -split "`n"
                    foreach ($l in $contentLines) {
                        if ($l -match '^\s*\d+:\s*(.*)') {
                            $lines += $Matches[1]
                        }
                    }
                    
                    if ($lines.Count -gt 5) {
                        $fileCode = $lines -join "`r`n"
                        $outPath = Join-Path $outputDir $filename
                        [System.IO.File]::WriteAllText($outPath, $fileCode)
                        Write-Host "Recovered from view_file: $filename ($($lines.Count) lines)"
                    }
                }
            }
        }
    } catch {
        # ignore parse errors
    }
}

import json
import os
import re

transcript_path = r"C:\Users\Taha SÄ°NGÄ°N\.gemini\antigravity\brain\2d7e92df-a8e4-45ec-9a24-0f68f5fb0003\.system_generated\logs\transcript_full.jsonl"
output_dir = r"C:\Users\Public\lojistikyol\frontend_recovered"

if not os.path.exists(output_dir):
    os.makedirs(output_dir)

files_history = {}

with open(transcript_path, "r", encoding="utf-8") as f:
    for line in f:
        try:
            step = json.loads(line)
        except Exception:
            continue
            
        tool_calls = step.get("tool_calls", [])
        for tc in tool_calls:
            name = tc.get("name")
            args = tc.get("args", {})
            if isinstance(args, str):
                try:
                    args = json.loads(args)
                except Exception:
                    continue
            
            # Match write_to_file
            if name == "write_to_file":
                target = args.get("TargetFile")
                content = args.get("CodeContent")
                if target and content:
                    filename = os.path.basename(target)
                    files_history[filename] = {"type": "write", "content": content}
            
            # Match replace_file_content (if we want to log it)
            elif name == "replace_file_content":
                target = args.get("TargetFile")
                if target:
                    filename = os.path.basename(target)
                    if filename not in files_history:
                        files_history[filename] = {"type": "edit", "edits": []}
                    if "edits" in files_history[filename]:
                        files_history[filename]["edits"].append(args)

        # Also look at step results (for view_file output!)
        # Some steps are SYSTEM or DONE containing tool responses
        if step.get("type") == "PLANNER_RESPONSE" and step.get("status") == "DONE":
            # Check if there is content with file contents
            content = step.get("content", "")
            if "File Path: " in content and "Total Lines: " in content:
                # This is a view_file output!
                path_match = re.search(r"File Path: `file:///(.*?)`", content)
                if path_match:
                    path = path_match.group(1).replace("%20", " ")
                    filename = os.path.basename(path)
                    # Extract lines
                    lines = []
                    for l in content.split("\n"):
                        m = re.match(r"^\s*\d+:\s*(.*)", l)
                        if m:
                            lines.append(m.group(1))
                    if lines:
                        file_code = "\n".join(lines)
                        files_history[filename] = {"type": "view", "content": file_code}

print("Found file histories:")
for fname, info in files_history.items():
    print(f"- {fname}: {info['type']}")
    # Save the most complete static version we found
    if "content" in info:
        out_path = os.path.join(output_dir, fname)
        with open(out_path, "w", encoding="utf-8") as out_f:
            out_f.write(info["content"])
        print(f"  Saved to {out_path}")

class MarkdownSplitter:

    def __init__(self, max_bytes=2048, encoding="utf-8"):
        self.max_bytes = max_bytes
        self.encoding = encoding

    def split(self, text):
        if len(text.encode(self.encoding)) <= self.max_bytes:
            return [text]

        parts = []
        lines = text.splitlines(keepends=True)
        i = 0
        N = len(lines)

        while i < N:
            chunk = ""
            if lines[i].strip().startswith("```"):
                code_block = []
                code_block.append(lines[i])
                i += 1
                while i < N:
                    code_block.append(lines[i])
                    if lines[i].strip().startswith("```") and len(code_block) > 1:
                        i += 1
                        break
                    i += 1
                parts.append("".join(code_block))
                continue
            if lines[i].lstrip().startswith("|"):
                table_block = []
                while i < N and (lines[i].lstrip().startswith("|") or not lines[i].strip()):
                    table_block.append(lines[i])
                    i += 1
                parts.append("".join(table_block))
                continue
            while i < N:
                line = lines[i]
                test_chunk = chunk + line
                if len(test_chunk.encode(self.encoding)) > self.max_bytes:
                    if not chunk:
                        subline = ""
                        for idx, c in enumerate(line):
                            candidate = chunk + subline + c
                            if len(candidate.encode(self.encoding)) > self.max_bytes:
                                break
                            subline += c
                        chunk += subline
                        break
                    else:
                        break
                else:
                    chunk = test_chunk
                    i += 1
                    if i < N and (lines[i].strip().startswith("```") or lines[i].lstrip().startswith("|")):
                        break
            if chunk:
                parts.append(chunk)

        return [p for p in parts if p]

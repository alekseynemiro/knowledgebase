import hashlib
import os
import pathspec

def compute_file_hash(file_path, algorithm="sha256") -> str:
    hash_func = hashlib.new(algorithm)

    with open(file_path, "rb") as file:
        while chunk := file.read(8192):
            hash_func.update(chunk)

    return hash_func.hexdigest()

def read_gitignore(directory: str) -> pathspec.PathSpec:
    patterns = [".git/", ".gitignore"]
    git_path = os.path.join(directory, ".git")

    while not os.path.exists(git_path) and not git_path == "/.git":
        git_path = os.path.abspath(os.path.join(directory, "..", ".git"))

    gitignore_path = os.path.abspath(os.path.join(git_path, "..", ".gitignore"))

    if os.path.exists(gitignore_path):
        with open(gitignore_path, "r") as file:
            patterns += file.read().splitlines()

    return (pathspec.PathSpec.from_lines("gitwildmatch", patterns), os.path.dirname(gitignore_path))

def get_file_list(directory: str, file_types: str | list | None=None) -> list[str]:
    if file_types is not None:
        if isinstance(file_types, str):
            file_types = [file_types]
        file_types = [ext if ext.startswith(".") else f".{ext}" for ext in file_types]

    result = []

    (spec, git_root) = read_gitignore(directory)

    base_path = os.path.relpath(directory, git_root)

    for root, dirs, files in os.walk(directory):
        for file in files:
            file_path = os.path.join(root, file)

            if spec and spec.match_file(os.path.join(base_path, os.path.relpath(file_path, directory))):
                continue

            if file_types is not None:
                file_ext = os.path.splitext(file)[1].lower()
                if file_ext not in [ext.lower() for ext in file_types]:
                    continue

            result.append(file_path)

    return result

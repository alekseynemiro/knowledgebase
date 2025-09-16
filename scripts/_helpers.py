import hashlib

def compute_file_hash(file_path, algorithm="sha256") -> str:
    hash_func = hashlib.new(algorithm)

    with open(file_path, "rb") as file:
        while chunk := file.read(8192):
            hash_func.update(chunk)

    return hash_func.hexdigest()

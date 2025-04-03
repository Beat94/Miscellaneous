# Requirments
- Pre-Installed Ollama-Client (https://ollama.com/search)  
- min. llama3.2
- python
- installed PIP-Packed Fastapi, uvicorn, requests
 => pip install fastapi uvicorn requests

# Note
This python-script is developed entierly made by googles gemini.

# Start
```cmd
uvicorn ollamaSrvApi:app --reload --workers 1
```
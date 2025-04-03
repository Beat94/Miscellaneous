from fastapi import FastAPI, HTTPException
from pydantic import BaseModel
import requests
from typing import Dict

app = FastAPI()
OLLAMA_BASE_URL = "http://localhost:11434"  # Standard Ollama API URL
DEFAULT_MODEL = "llama3.2"  # Standardmäßig zu verwendendes LLM

class SummaryRequest(BaseModel):
    text: str
    model: str = DEFAULT_MODEL
    max_tokens: int = 100  # Optionale Begrenzung der Zusammenfassungslänge

class SummaryResponse(BaseModel):
    summary: str

@app.get("/lolz")
async def readLolz():
    print("Lolz called")
    return {"message": "Test"}

@app.post("/summarize", response_model=SummaryResponse)
async def summarize_text(request_data: SummaryRequest):
    prompt = f"Fasse kurz zusammen: {request_data.text}"
    ollama_data = {
        "model": request_data.model,
        "prompt": prompt,
        "max_tokens": request_data.max_tokens,
    }

    ollama_url = f"{OLLAMA_BASE_URL}/api/generate"
    try:
        print(f"prompt sent: {prompt}")
        response = requests.post(ollama_url, json=ollama_data, stream=True)
        response.raise_for_status()
        print("i was here")

        summary = ""
        for line in response.iter_lines():
            if line:
                import json
                try:
                    data = json.loads(line.decode('utf-8'))
                    if 'response' in data:
                        summary += data['response']
                        print("Antwort erhalten")
                except json.JSONDecodeError:
                    print(f"Fehler beim Dekodieren der JSON-Zeile: {line}")

        return {"summary": summary.strip()}

    except requests.exceptions.RequestException as e:
        raise HTTPException(status_code=500, detail=f"Fehler bei der Kommunikation mit Ollama: {e}")
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Ein unerwarteter Fehler ist aufgetreten: {e}")

if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="0.0.0.0", port=8000, reload=True)
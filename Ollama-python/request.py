import requests
import json

url = "http://127.0.0.1:8000/summarize"
payload = {
    "text": "Dies ist ein sehr langer Text, der viele irrelevante Details enthält und eigentlich nur darum geht, dass das Wetter heute schön ist und die Sonne scheint. Trotzdem schreibe ich noch ein paar mehr Sätze, um den Text künstlich zu verlängern, damit die Zusammenfassung auch wirklich etwas zu tun hat.",
    "model": "llama3.2",
    "max_tokens": 60
}
headers = {"Content-Type": "application/json"}

try:
    response = requests.post(url, headers=headers, json=payload)
    response.raise_for_status()
    print(response.json())
except requests.exceptions.RequestException as e:
    print(f"Fehler: {e}")
import json

from fastapi import FastAPI, Body
from pydantic import BaseModel

app = FastAPI()


class Item(BaseModel):
    account: str = None
    passwd: str = None


@app.get("/")
async def root():
    return {"execute": "nima"}


@app.get("/hello/{name}")
async def say_hello(name: str):
    return {"message": f"Hello {name}"}


@app.post("/login")
async def login(
        account: str = Body(..., embed=True),
        passwd: str = Body(..., embed=True)
):
    return {"account": account, "passwd": passwd, "execute": "login"}

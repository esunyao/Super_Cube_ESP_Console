import requests,warnings
import urllib3
from pydantic import BaseModel


url = 'https://localhost:8000/login'
# 以字典的形式构造数据
data = {
    "account": "asdf",
    "passwd": "asdjfie"
}
# 与 get 请求一样，r 为响应对象
r = requests.post(url, json=data, verify=False)
# 查看响应结果
print(r.json())
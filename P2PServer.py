import requests
from os import listdir
from os.path import isfile, join
from socket import *
import threading

url = "https://actorrest220240228125032.azurewebsites.net/api/FileEndpoints"
ip = "10.200.130.41"
port = 55823
mypath = "c:/temp"

onlyfiles = [f for f in listdir(mypath) if isfile(join(mypath, f))]

for filename in onlyfiles:
    fileEndpoint = {"filename":filename,"ip":ip, "port":port}
    print(requests.post(url, json=fileEndpoint))

def handle_client(connectionSocket, addr):
    filename = connectionSocket.recv(1024).decode().strip()
    filename = filename[4:]

    file = open('C:/temp/' + filename, 'rb')
    file_data = file.read(1024)
    while (file_data):
        print('Sending...')
        connectionSocket.send(file_data)
        file_data = file.read(1024)
    file.close()
    print("Done Sending")
    connectionSocket.shutdown(SHUT_WR)
    connectionSocket.close()

serverSocket = socket(AF_INET, SOCK_STREAM)
serverSocket.bind(('', port))
serverSocket.listen(1)
print('Server is ready to listen')
while True:
    connectionSocket, addr = serverSocket.accept()
    threading.Thread(target=handle_client, 
                     args=(connectionSocket, addr)).start()
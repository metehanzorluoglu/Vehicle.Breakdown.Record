# EClinicsHospitalService
## Creating .ssh Public Key

### Creating .ssh folder <br/>
`mkdir ~/.ssh`<br/>
`chmod 700 ~/.ssh`<br/>

### Enter .ssh folder <br/>
`cd ~/.ssh`<br/>
`ssh-keygen -t rsa`<br/><br/>
`cat id_rsa.pub`<br/><br/>
<img width="488" alt="Screen Shot 2022-03-02 at 15 17 03" src="https://user-images.githubusercontent.com/57620464/156432464-f7e32d83-7679-458f-9a4e-75fb428bc031.png">
<br/>

## Entiring your public key on Ceiba Azure DevOps<br/>
<br/>

![Screen Shot 2022-03-02 at 22 04 08](https://user-images.githubusercontent.com/57620464/156432739-9645882b-aa3a-4cc7-809f-09aac63040be.png)<br/>
![Screen Shot 2022-03-02 at 22 07 20](https://user-images.githubusercontent.com/57620464/156432764-46a1eaa1-b45f-4e5a-811f-a43c8cf4b7ea.png)<br/>
![Screen Shot 2022-03-02 at 22 08 27](https://user-images.githubusercontent.com/57620464/156432787-72ea8aa0-57e4-46b4-8a48-825774fc3a57.png)<br/>
![Screen Shot 2022-03-02 at 22 10 08](https://user-images.githubusercontent.com/57620464/156432795-7cf3606b-de8b-42b6-9905-52e2c8eede81.png)<br/>
![Screen Shot 2022-03-02 at 22 26 13](https://user-images.githubusercontent.com/57620464/156434562-147fc6bb-8e55-45fd-918d-f8944ac0e0cb.png)<br/>


## Clone and Backup <br/>
`git clone ceibaeclinics@vs-ssh.visualstudio.com:v3/ceibaeclinics/EClinicsHospitalService/EClinicsHospitalService` for Clone<br/> 
`rsync -azv ubuntu@db1.api.ceibateleicu.com:/home/ubuntu/<DateOfBackup>_backup.gz.`for Backup<br/>
`gzip -d <DateOfBackup>_backup.gz`<br/>

## Creating Database <br/>
### Enter Database <br/>
`psql -U postgres`<br/>
`create user "CeibaSa" with password 'Ceiba@Tele.123';`<br/>
`create database "CeibaHospitalDB" with owner "CeibaSa";`<br/>
`\l`<br/>
![Screen Shot 2022-03-02 at 16 06 39](https://user-images.githubusercontent.com/57620464/156367567-7f5a1778-a6b1-43c4-86aa-a8ad77c74ff8.png)
<br/>
`exit`<br/>

### Loading Backup into Database <br/>
`psql -U "CeibaSa" -d "CeibaHospitalDB" < <DateOfBackup>_backup`<br/>
#### Password =Ceiba@Tele.123<br/>

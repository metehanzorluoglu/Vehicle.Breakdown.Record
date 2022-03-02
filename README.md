# EClinicsHospitalService
## Creating .ssh Public Key

### Creating .ssh file <br/>
`mkdir .ssh`<br/>
`chmod 700 /.ssh`<br/>
### Enter .ssh file <br/>
`cd .ssh`<br/>
`ssh-keygen -t rsa`<br/><br/>
`cat id_rsa.pub`<br/><br/>
<img width="488" alt="Screen Shot 2022-03-02 at 15 17 03" src="https://user-images.githubusercontent.com/57620464/156360290-b92deb00-f899-4e1b-8535-f70c9846bbbc.png">
<br/>
## After Entiring your public key on Ceiba Connection by Ceiba <br/>
### Trying your Connection <br/>
`ssh ubuntu@db1.api.ceibateleicu.com`<br/>
`CeibaSa`<br/>
`Ceiba@Tele.123`<br/>
`ssh -L 6005:localhost:5432 ubuntu@db1.api.ceibateleicu.com`
## Clone and Backup <br/>
`git clone ceibaeclinics@vs-ssh.visualstudio.com:v3/ceibaeclinics/EClinicsHospitalService/EClinicsHospitalService` for Clone<br/> 
`rsync -azv ubuntu@db1.api.ceibateleicu.com:/home/ubuntu/2021-09-26_backup.gz .`for Backup<br/>
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

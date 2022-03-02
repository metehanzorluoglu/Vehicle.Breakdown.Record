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
`cd ~/<your saving path>`<br/>
`rsync -azv ubuntu@db1.api.ceibateleicu.com:/home/ubuntu/2021-09-26_backup.gz .`for Backup<br/>
`gzip -d 2021-09-26_backup.gz`<br/>

## Creating Database <br/>
### Requirements <br/>
* PostgreSql Database 
* psql Cli 
* pgAdmin 4 <br/>

### Enter Database <br/>
`psql -U postgres`<br/>
`create user "CeibaSa" with password 'Ceiba@Tele.123';`<br/>
`create database "CeibaHospitalDB" with owner "CeibaSa";`<br/>
`\l`<br/>
![Screen Shot 2022-03-02 at 16 06 39](https://user-images.githubusercontent.com/57620464/156367567-7f5a1778-a6b1-43c4-86aa-a8ad77c74ff8.png)
<br/>
`exit`<br/>

### Loading Backup into Database <br/>
`psql -U "CeibaSa" -d "CeibaHospitalDB" < 2021-09-26_backup.gz`<br/>
- Password = Ceiba@Tele.123<br/>

### Adding New Query on Database <br/>

- Copy The Query
- Execute The Query<br/>

`INSERT INTO "Shared"."Users" ("Id", "RoleId", "UserName", "Password", "FirstName", "LastName", "Email", "ContactNo", "PersonnalId", "DateOfBirth", "CreatedDate", "ModifiedDate", "LastLoginAttempt", "CreatedById", "ModifiedById", "TitleId", "SpecialityId", "IsActive", "IsFirstLogin","IsPasswordReset", "TotpSecretKey") VALUES (1, 1, 'string12', '$2a$11$2xI4kDIRd5pjRFKMghHgw.kpG2nbbVru4VjT2515fKd0jj/6AtC3W', 'string', 'string', 'allen@gmail.com', 'string', 'string', '2019-10-10 13:35:19.657000 +00:00', '2019-10-10 13:37:41.443561 +00:00', null, null, null, null, 1, 1, true, false, false, null);` <br/>

![Screen Shot 2022-03-02 at 23 55 16](https://user-images.githubusercontent.com/57620464/156449077-af5687c5-e249-4589-95c9-9dd59c06b07d.png) <br/>

## Changing The Code for Database Connection <br/>

* Enter /.../.../.../EClinicsHospitalService/src/HospitalService.API/Properties/launchSettings.json

![Screen Shot 2022-03-02 at 22 35 41](https://user-images.githubusercontent.com/57620464/156446243-6b2e5764-d9d1-4ed2-bb72-aa7b63de985f.png)<br/>

















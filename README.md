# EClinicsHospitalService
## Creating .ssh Public Key

### Creating .ssh folder <br/>
`mkdir ~/.ssh`<br/>
`chmod 700 ~/.ssh`<br/>

### Enter .ssh folder <br/>
`cd ~/.ssh`<br/>
`ssh-keygen -t rsa`<br/><br/>
`cat id_rsa.pub`<br/><br/>
<img width="488" alt="1" src="https://user-images.githubusercontent.com/57620464/156518942-d4ffb05f-1379-485a-bfb5-90732a1f8b7c.png">

<br/>

## Entiring your public key on your Ceiba Azure DevOps account<br/>
<br/>

![2](https://user-images.githubusercontent.com/57620464/156518986-4faf5497-30ad-4fcf-baab-5f7333f01c6f.png)<br/>
![3](https://user-images.githubusercontent.com/57620464/156519062-b4acbca2-27be-4106-af33-7b356d024451.png)<br/>
![4](https://user-images.githubusercontent.com/57620464/156519103-0b12a25f-8097-4b4c-a8a6-2069c0c5c4c6.png)<br/>
![5](https://user-images.githubusercontent.com/57620464/156519136-cd9a13f5-2c72-4e10-b647-18c28db26804.png)<br/>
![6](https://user-images.githubusercontent.com/57620464/156519166-6e7b6856-73b1-470b-9e62-f1e30bf5d66e.png)<br/>


## Clone and Backup <br/>
`git clone ceibaeclinics@vs-ssh.visualstudio.com:v3/ceibaeclinics/EClinicsHospitalService/EClinicsHospitalService` for Clone<br/> 
`rsync -azv ubuntu@db1.api.ceibateleicu.com:/home/ubuntu/2021-09-26_backup.gz /path/to/want `for Backup<br/>
`gzip -d /path/to/backupfile`<br/>

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
![7](https://user-images.githubusercontent.com/57620464/156519216-a52295c8-d4ed-4e3e-98aa-6636092317ab.png)<br/>
`exit`<br/>

### Loading Backup into Database <br/>
`psql -U "CeibaSa" -d "CeibaHospitalDB" < /path/to/backupfile`<br/>
- Password = Ceiba@Tele.123<br/>

## Changing The Code for Database Connection <br/>

* Enter /.../.../.../EClinicsHospitalService/src/HospitalService.API/Properties/launchSettings.json

![8](https://user-images.githubusercontent.com/57620464/156519285-296017dd-4ac9-478e-85b9-252af3350aa6.png)<br/>


### Adding New Query on Database <br/>
If you are getting FK_Acceptances_User error, you can follow the steps below.
- Copy The Query
- Execute The Query<br/>

`INSERT INTO "Shared"."Users" ("Id", "RoleId", "UserName", "Password", "FirstName", "LastName", "Email", "ContactNo", "PersonnalId", "DateOfBirth", "CreatedDate", "ModifiedDate", "LastLoginAttempt", "CreatedById", "ModifiedById", "TitleId", "SpecialityId", "IsActive", "IsFirstLogin","IsPasswordReset", "TotpSecretKey") VALUES (1, 1, 'string12', '$2a$11$2xI4kDIRd5pjRFKMghHgw.kpG2nbbVru4VjT2515fKd0jj/6AtC3W', 'string', 'string', 'allen@gmail.com', 'string', 'string', '2019-10-10 13:35:19.657000 +00:00', '2019-10-10 13:37:41.443561 +00:00', null, null, null, null, 1, 1, true, false, false, null);` <br/>

(if you get an error message that is <column "Password" of relation "Users" does not exist>, "Password" column and "Password Value" should be removed from the query above.)

![9](https://user-images.githubusercontent.com/57620464/156519382-631cc620-c661-4dd0-bc34-535c6ebf9a54.png) <br/>




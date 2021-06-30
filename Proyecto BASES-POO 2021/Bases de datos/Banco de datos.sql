-- Creando base de datos y seleccionandola para realizar consultas 
CREATE DATABASE Proyecto_POO_BDD;
USE Proyecto_POO_BDD; 			
SET LANGUAGE us_english;

-- Tables section.
CREATE TABLE CITIZEN(
id int PRIMARY KEY,
dui varchar(10) NOT NULL,
full_name varchar(60) NOT NULL,
age int NOT NULL,
direction varchar(60) NOT NULL,
telephone int NOT NULL,
email varchar(30),
id_chronic_diseases int,
id_occupation int NOT NULL
);

CREATE TABLE CHRONIC_DISEASES(
id int PRIMARY KEY,
common_name varchar(60)
);

CREATE TABLE OCUPATION(
id int PRIMARY KEY,
common_name varchar(20)
);

CREATE TABLE APPOINTMENT(
id int PRIMARY KEY,
reservation_date datetime,
id_priority int NOT NULL,
id_citizen int NOT NULL,
id_employee int NOT NULL,
id_vaccination int,
id_vaccine int,
assistance_date datetime,
vaccination_date datetime,
observation bit
);

CREATE TABLE VACCINE(
id int PRIMARY KEY,
vaccine varchar(30)
);

CREATE TABLE OBSERBATION(
id_appointment int NOT NULL,
id_symptom int NOT NULL
);

CREATE TABLE SYMPTOM_CITIZEN(
id int PRIMARY KEY ,
id_appointmen int ,
symptom varchar(40) ,
symptomminutes int 
);

CREATE TABLE SYMPTOM_REACTION(
id int PRIMARY KEY,
id_symptom int,
reaction_time int NOT NULL
);

CREATE TABLE SYMPTOM(
id int PRIMARY KEY,
symptom varchar(30)
);


CREATE TABLE PRIORITY_(
id int PRIMARY KEY,
priority_ varchar(20)
);

CREATE TABLE EMPLOYEE(
id int PRIMARY KEY,
fullname varchar(60) NOT NULL,
addresses varchar(60) NOT NULL,
email varchar(30) NOT NULL,
id_job int,
id_management_account int
);

CREATE TABLE MANAGEMENT_ACCOUNT(
id int PRIMARY KEY,
user_management varchar(20) NOT NULL,
password_management varchar(25) NOT NULL
);

CREATE TABLE INOBSERVATION(
id int PRIMARY KEY,
fullname varchar(60) NOT NULL,
vaccine1 varchar(60) NOT NULL,
symptom varchar(30),
minutesymptom int,
);


CREATE TABLE JOB(
id int PRIMARY KEY,
job varchar(30)
);

CREATE TABLE RECORD(
id_employee int NOT NULL,
id_management_login int NOT NULL
);

CREATE TABLE MANAGEMENT_LOGIN(
id int PRIMARY KEY,
date_hour datetime NOT NULL,
id_cabin int NOT NULL
);

CREATE TABLE CABIN(
id int PRIMARY KEY,
id_employee int NOT NULL,
direction varchar(60) NOT NULL,
telephone int NOT NULL,
email varchar(30) NOT NULL
);

-- Primary/Foreign Key section.
-- PK Definition 
ALTER TABLE OBSERBATION ADD PRIMARY KEY (id_appointment, id_symptom);
ALTER TABLE RECORD ADD PRIMARY KEY (id_employee, id_management_login);
-- FK Detinition
-- PRIORITY_ -> APPOINTMENT
ALTER TABLE APPOINTMENT ADD FOREIGN KEY (id_priority) REFERENCES PRIORITY_(id);
-- SYMPTOM -> SYMPTOM_REACTION
ALTER TABLE SYMPTOM_REACTION ADD FOREIGN KEY (id_symptom) REFERENCES SYMPTOM(id);
-- CHRONIC_DISEASES -> CITIZEN
ALTER TABLE CITIZEN ADD FOREIGN KEY (id_chronic_diseases) REFERENCES CHRONIC_DISEASES(id);
-- OCUPATION -> CITIZEN
ALTER TABLE CITIZEN ADD FOREIGN KEY (id_occupation) REFERENCES OCUPATION(id);
-- CITIZEN -> APPOINTMENT
ALTER TABLE APPOINTMENT ADD FOREIGN KEY (id_citizen) REFERENCES CITIZEN(id);
-- EMPLOYEE -> APPOINTMENT
ALTER TABLE APPOINTMENT ADD FOREIGN KEY (id_employee) REFERENCES EMPLOYEE(id);
-- VACCINE -> APPOINTMENT
ALTER TABLE APPOINTMENT ADD FOREIGN KEY (id_vaccine) REFERENCES VACCINE(id);
-- APPOINTMENT -> OBSERBATION
ALTER TABLE OBSERBATION ADD FOREIGN KEY (id_appointment) REFERENCES APPOINTMENT(id);
-- SYMPTOM -> OBSERBATION
ALTER TABLE OBSERBATION ADD FOREIGN KEY (id_symptom) REFERENCES SYMPTOM(id);
-- JOB -> EMPLOYEE
ALTER TABLE EMPLOYEE ADD FOREIGN KEY (id_job) REFERENCES JOB(id);

-- MANAGEMENT_ACCOUNT -> EMPLOYEE
ALTER TABLE EMPLOYEE ADD FOREIGN KEY (id_management_account) REFERENCES MANAGEMENT_ACCOUNT(id);
-- EMPLOYEE -> RECORD
ALTER TABLE RECORD ADD FOREIGN KEY (id_employee) REFERENCES EMPLOYEE(id);
-- MANAGEMENT_LOGIN -> RECORD
ALTER TABLE RECORD ADD FOREIGN KEY (id_management_login) REFERENCES MANAGEMENT_LOGIN(id);
-- EMPLOYEE -> CABIN
ALTER TABLE CABIN ADD FOREIGN KEY (id_employee) REFERENCES EMPLOYEE(id);
-- CABIN -> MANAGEMENT_LOGIN
ALTER TABLE MANAGEMENT_LOGIN ADD FOREIGN KEY (id_cabin) REFERENCES CABIN(id);

INSERT INTO OCUPATION VALUES(1,'civil');
INSERT INTO OCUPATION VALUES(2,'educación');
INSERT INTO OCUPATION VALUES(3,'salud');
INSERT INTO OCUPATION VALUES(4,'PNC');
INSERT INTO OCUPATION VALUES(5,'gobierno');
INSERT INTO OCUPATION VALUES(6,'fuerza armada');
INSERT INTO OCUPATION VALUES(7,'periodismo');
INSERT INTO OCUPATION VALUES(8,'cuerpo de socorro');
INSERT INTO OCUPATION VALUES(9,'personal de frontera');
INSERT INTO OCUPATION VALUES(10,'centro penal');

INSERT INTO CHRONIC_DISEASES VALUES(1,'Alzheimer');
INSERT INTO CHRONIC_DISEASES VALUES(2,'Artritis');
INSERT INTO CHRONIC_DISEASES VALUES(3,'Asma');
INSERT INTO CHRONIC_DISEASES VALUES(4,'Cáncer');
INSERT INTO CHRONIC_DISEASES VALUES(5,'Demencia');
INSERT INTO CHRONIC_DISEASES VALUES(6,'Diabetes');
INSERT INTO CHRONIC_DISEASES VALUES(7,'EPOC (Enfermedad pulmonal obstructiva crónica)');
INSERT INTO CHRONIC_DISEASES VALUES(8,'Enfermedad de Crohn');
INSERT INTO CHRONIC_DISEASES VALUES(9,'Epilipsia');
INSERT INTO CHRONIC_DISEASES VALUES(10,'Enfermedad del corazón');
INSERT INTO CHRONIC_DISEASES VALUES(11,'Fibrosis quística');
INSERT INTO CHRONIC_DISEASES VALUES(12,'Gonorrea');
INSERT INTO CHRONIC_DISEASES VALUES(13,'Herpes genital');
INSERT INTO CHRONIC_DISEASES VALUES(14,'Parkinson');
INSERT INTO CHRONIC_DISEASES VALUES(15,'Sifilis');
INSERT INTO CHRONIC_DISEASES VALUES(16,'Trastornos de humor');
INSERT INTO CHRONIC_DISEASES VALUES(17,'VIH/SIDA');
INSERT INTO CHRONIC_DISEASES VALUES(18,'Autismo');
INSERT INTO CHRONIC_DISEASES VALUES(19,'Deficiencia visual');
INSERT INTO CHRONIC_DISEASES VALUES(20,'Trastono de lengua');
INSERT INTO CHRONIC_DISEASES VALUES(21,'Deficiencia auditiva');


INSERT INTO VACCINE VALUES(1,'Primera vacuna');
INSERT INTO VACCINE VALUES(2,'Segunda vacuna');

INSERT INTO PRIORITY_ VALUES(1,'Alta');
INSERT INTO PRIORITY_ VALUES(2,'Comun');

INSERT INTO SYMPTOM VALUES(1,'Fiebre o escalofríos');
INSERT INTO SYMPTOM VALUES(2,'Tos');
INSERT INTO SYMPTOM VALUES(3,'Dificultad para respirar');
INSERT INTO SYMPTOM VALUES(4,'Fatiga');
INSERT INTO SYMPTOM VALUES(5,'Dolores musculares');
INSERT INTO SYMPTOM VALUES(6,'Dolor de cabeza');
INSERT INTO SYMPTOM VALUES(7,'Pérdida del olfato o el gusto');
INSERT INTO SYMPTOM VALUES(8,'Dolor de garganta');
INSERT INTO SYMPTOM VALUES(9,'Congestión o moqueo');
INSERT INTO SYMPTOM VALUES(10,'Náuseas o vómitos');
INSERT INTO SYMPTOM VALUES(11,'Diarrea');

INSERT INTO MANAGEMENT_ACCOUNT VALUES(1,'LLuis.Exe', 'contraseña');
INSERT INTO MANAGEMENT_ACCOUNT VALUES(2,'DJK3lex', 'contraseña');
INSERT INTO MANAGEMENT_ACCOUNT VALUES(3,'Nekado', 'contraseña');
INSERT INTO MANAGEMENT_ACCOUNT VALUES(4,'ARION', 'contraseña');

INSERT INTO JOB VALUES(1,'Gestor');
INSERT INTO JOB VALUES(2,'Doctor');
INSERT INTO JOB VALUES(3,'Enfermera');
INSERT INTO JOB VALUES(4,'Seguridad');

INSERT INTO EMPLOYEE VALUES(1,'Luis Serrano', 'EN MI CASITA', 'lluis.exe@gmail.com', 1, 1);
INSERT INTO EMPLOYEE VALUES(2,'Kevin Orellana', 'EN SU CASITA', 'djkelex.exe@gmail.com', 1, 2);
INSERT INTO EMPLOYEE VALUES(3,'Alejandra Serrano', 'EN SU CASITA', 'nekado.exe@gmail.com', 1, 3);
INSERT INTO EMPLOYEE VALUES(4,'Luis Molina', 'EN SU CASITA', 'luisito.exe@gmail.com', 1, 4);
INSERT INTO EMPLOYEE VALUES(5,'Juan Perez', 'EN SU CASITA', 'lluis.exe@gmail.com', 4, NULL);
INSERT INTO EMPLOYEE VALUES(6,'Mark Zuckerberg', 'EN ROBOTONIA', 'lluis.exe@gmail.com', 3, NULL);
INSERT INTO EMPLOYEE VALUES(7,'Maria Rosales', 'EN SU CASITA', 'lluis.exe@gmail.com', 2, NULL);
INSERT INTO EMPLOYEE VALUES(8,'Faker', 'EN EL OLIMPO', 'hide_on_the_bush.exe@gmail.com', 1, 1);

INSERT INTO CABIN VALUES(1, 1, 'En la plaza', 22284596, 'vacunas_la_plaza@covid.sv');
INSERT INTO CABIN VALUES(2, 4, 'aya por jan miguel', 22284597, 'vacunas_jan_miguel@covid.sv');
INSERT INTO CABIN VALUES(3, 2, 'pal centro', 22284598, 'vacunas_centro@covid.sv');
INSERT INTO CABIN VALUES(4, 3, 'tecla', 22284599, 'vacunas_tecla@covid.sv');

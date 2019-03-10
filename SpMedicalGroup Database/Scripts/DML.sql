USE SPMEDICALGROUP_MANHA

/*
INSERT INTO ESPECIALIDADES(ESPECIALIDADE)
VALUES	('Anestesiologia'),
			('Angiologia'),
			('Cardiologia'),
			('Cirurgia Cardiovascular'),
			('Cirurgia da Mão'),
			('Cirurgia do Aparelho Digestivo'),
			('Cirurgia Geral'),
			('Cirurgia Pediátrica'),
			('Cirurgia Plástica'),
			('Cirurgia Torácica'),
			('Cirurgia Vascular'),
			('Dermatologia'),
			('Radioterapia'),
			('Urologia'),
			('Pediatria'),
			('Psiquiatria')
*/
SELECT * FROM ESPECIALIDADES

/*
INSERT INTO CLINICAS(RAZAO_SOCIAL, NOME_FANTASIA, CNPJ, LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO)
VALUES	('SPMedGroup', 'SPMedicalGroup', 123456789012, 'Alameda Barão de Limeira', 539, 'Santa Cecília', 'São Paulo', 'SP')
*/
SELECT * FROM CLINICAS

/*
INSERT INTO CREDENCIAIS(CREDENCIAL)
VALUES	('Administrador'),('Medico'), ('Paciente')
*/
SELECT * FROM CREDENCIAIS

/*
INSERT INTO USUARIOS(EMAIL, SENHA, ID_CREDENCIAL)
VALUES	('gabriel.cmartins11@gmail.com', 'admin', 1),
('ricardo.lemos@spmedicalgroup.com.br', 'teste', 2), ('roberto.possarle@spmedicalgroup.com.br', 'teste', 2), ('helena.souza@spmedicalgroup.com.br', 'teste', 2)
*/
SELECT * FROM USUARIOS

/*
INSERT INTO MEDICOS(CRM, NOME, ID_USUARIO, ID_ESPECIALIDADE, ID_CLINICA)
VALUES ('54356SP', 'Ricardo Lemos', 2, 1, 1), ('53452SP', 'Roberto Possarle', 3, 16, 1), ('65463SP', 'Helena Strada', 4, 15, 1)
*/
SELECT * FROM MEDICOS

/*
INSERT INTO USUARIOS(EMAIL, SENHA, ID_CREDENCIAL)
VALUES ('ligia@gmail.com', 'teste', 3), ('alexandre@gmail.com', 'teste', 3), ('fernando@gmail.com', 'teste', 3), ('henrique@gmail.com', 'teste', 3), ('joao@hotmail.com', 'teste', 3), ('bruno@gmail.com', 'teste', 3), ('mariana@outlook.com', 'teste', 3)
*/
SELECT * FROM USUARIOS WHERE ID_CREDENCIAL = 3


INSERT INTO PACIENTES(NOME, RG, CPF, DATA_NASCIMENTO, LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, ID_USUARIO)
VALUES	--('Ligia',435225435 ,94839859000, '1983-10-13', '1134567654', 'Rua Estado de Israel', 240,'Vila Clementino' , 'São Paulo', 'SP', 5)
		--('Alexandre',326543457 ,73556944057 ,'2001-07-23' , '11987656543', 'Paulista', 1578, 'Bela Vista' , 'São Paulo', 'SP', 6)
		--('Fernando',546365253 ,16839338002 ,'1978-10-10', '11972084453', 'Av. Ibirapuera', 2927, 'Indianópolis', 'São Paulo', 'SP', 7)
		--('Henrique',543663625 ,14332654765 , '1985-10-13', '1134566543', ' R.Vitória', 120, 'Vila São Jorge', 'Barueri', 'SP', 8)
		--('João' , 325444441, 91305348010, '1975-08-27', '1176566377', 'R. Ver. Geraldo de Camargo', 66, 'Santa Luzia', 'Ribeirão Pires', 'SP', 9)
		--('Bruno' ,545662667 ,79799299004,'1972-03-21', '1134567654', 'Alameda dos Arapanés', 945, 'Indianópolis', 'São Paulo', 'SP', 10)
		--('Mariana' ,545662668 ,13771913039, '2018-03-15', 'R. São Antonio',232 ,'Vila Universal', 'Barueri', 'SP', 11)
SELECT * FROM PACIENTES

/*
INSERT INTO STATUS_CONSULTA(STATUS_CONSULTA)
VALUES	('Agendada'), ('Realizada'), ('Cancelada')
*/
SELECT * FROM STATUS_CONSULTA

SELECT * FROM MEDICOS
SELECT * FROM PACIENTES
SELECT * FROM STATUS_CONSULTA
/*
INSERT INTO CONSULTAS(ID_MEDICO, ID_PACIENTE, DATA_CONSULTA,HORA_CONSULTA, STATUS_CONSULTA)
VALUES	(2, 9, '2019-02-08', '15:00:00', 1),
		(2, 9, '2019-01-20', '15:00:00', 2),
		(4, 6, '2018-01-06', '10:00:00', 3),
		(4, 4, '2019-02-07', '11:00:00', 2),
		(4, 6, '2018-02-06', '10:00:00', 2),
		(3, 5, '2019-02-07', '11:00:00', 3),
		(3, 5, '2019-02-09', '11:00:00', 1)
*/
SELECT * FROM CONSULTAS
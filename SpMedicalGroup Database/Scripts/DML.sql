-- USE SPMEDICALGROUP_MANHA


-- INSERT INTO ESPECIALIDADES(ESPECIALIDADE)
-- VALUES	('Anestesiologia'),
-- 		('Angiologia'),
-- 		('Cardiologia'),
-- 		('Cirurgia Cardiovascular'),
-- 		('Cirurgia da Mão'),
-- 		('Cirurgia do Aparelho Digestivo'),
-- 		('Cirurgia Geral'),
-- 		('Cirurgia Pediátrica'),
-- 		('Cirurgia Plástica'),
-- 		('Cirurgia Torácica'),
-- 		('Cirurgia Vascular'),
-- 		('Dermatologia'),
-- 		('Radioterapia'),
-- 		('Urologia'),
-- 		('Pediatria'),
-- 		('Psiquiatria')

SELECT * FROM ESPECIALIDADES


-- INSERT INTO CLINICAS(RAZAO_SOCIAL, NOME_FANTASIA, CNPJ, LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO)
-- VALUES	('SPMedGroup', 'SPMedicalGroup', 123456789012, 'Alameda Barão de Limeira', 539, 'Santa Cecília', 'São Paulo', 'SP')

SELECT * FROM CLINICAS


-- INSERT INTO CREDENCIAIS(CREDENCIAL)
-- VALUES	('Administrador'),('Medico'), ('Paciente')

SELECT * FROM CREDENCIAIS


-- INSERT INTO USUARIOS(EMAIL, SENHA, ID_CREDENCIAL)
-- VALUES	('gabriel.cmartins11@gmail.com', 'admin', 1),
-- ('ricardo.lemos@spmedicalgroup.com.br', 'teste', 2), ('roberto.possarle@spmedicalgroup.com.br', 'teste', 2), ('helena.souza@spmedicalgroup.com.br', 'teste', 2)

SELECT * FROM USUARIOS


-- INSERT INTO MEDICOS(CRM, NOME, ID_USUARIO, ID_ESPECIALIDADE, ID_CLINICA)
-- VALUES ('54356SP', 'Ricardo Lemos', 2, 1, 1), ('53452SP', 'Roberto Possarle', 3, 16, 1), ('65463SP', 'Helena Strada', 4, 15, 1)

SELECT * FROM MEDICOS


-- INSERT INTO USUARIOS(EMAIL, SENHA, ID_CREDENCIAL)
-- VALUES ('ligia@gmail.com', 'teste', 3), ('alexandre@gmail.com', 'teste', 3), ('fernando@gmail.com', 'teste', 3), ('henrique@gmail.com', 'teste', 3), ('joao@hotmail.com', 'teste', 3), ('bruno@gmail.com', 'teste', 3), ('mariana@outlook.com', 'teste', 3)

SELECT * FROM USUARIOS WHERE ID_CREDENCIAL = 3


-- INSERT INTO PACIENTES (NOME, RG, CPF, DATA_NASCIMENTO, TELEFONE, LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, ID_USUARIO)
-- VALUES	('Ligia',435225435 ,94839859000, '1983-10-13', '1134567654', 'Rua Estado de Israel', 240,'Vila Clementino' , 'São Paulo', 'SP', 5), ('Alexandre',326543457 ,73556944057 ,'2001-07-23' , '11987656543', 'Paulista', 1578, 'Bela Vista' , 'São Paulo', 'SP', 6)

SELECT * FROM PACIENTES


-- INSERT INTO STATUS_CONSULTA(SITUACAO)
-- VALUES	('Agendada'), ('Realizada'), ('Cancelada')

SELECT * FROM STATUS_CONSULTA

SELECT * FROM MEDICOS
SELECT * FROM PACIENTES
SELECT * FROM STATUS_CONSULTA

-- INSERT INTO CONSULTAS(ID_MEDICO, ID_PACIENTE, DATA_CONSULTA,HORA_CONSULTA, ID_STATUS)
-- VALUES	(2, 1, '2019-02-08', '15:00:00', 1),
-- 		(2, 1, '2019-01-20', '15:00:00', 2),
-- 		(1, 1, '2018-01-06', '10:00:00', 3),
-- 		(1, 2, '2019-02-07', '11:00:00', 2),
-- 		(1, 2, '2018-02-06', '10:00:00', 2),
-- 		(3, 2, '2019-02-07', '11:00:00', 3),
-- 		(3, 2, '2019-02-09', '11:00:00', 1)

-- INSERT INTO CONSULTAS(DESCRICAO, ID_MEDICO, ID_PACIENTE, DATA_CONSULTA,HORA_CONSULTA, ID_STATUS)
-- VALUES 	('Descricao', 3, 1, '2020-01-24', '18:30:00', 1)

SELECT * FROM CONSULTAS
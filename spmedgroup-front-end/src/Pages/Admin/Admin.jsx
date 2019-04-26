import React, {Component} from 'react'
import './Admin.css'

import Navbar from '../../Components/Navbar-consultas/Navbar'

class Admin extends Component {
    constructor() {
        super();
        this.state = {
            nome:'',
            rg: '',
            cpf:'',
            datanascimento:'',
            logradouro:'',
            numero:'',
            bairro: '',
            cidade: '',
            estado: '',
            email: '',
            senha: '',
            
            idcredencial: ''
        }
    }

    cadastrar(e) {
        e.preventDefault()

        fetch('https://spmedgroup.azurewebsites.net/api/usuarios',
        {   method: 'POST',
            body : JSON.stringify(this.state),
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("usuario")
            }
        })
        .then(data => console.log(data))
        .catch(erro => console.log(erro))

        this.props.history.push('/admin/usuario')
    }

    atualizarNome(e) {
        this.setState({nome: e.target.value})
        console.log(this.state)
    }

    atualizarRg(e) {
        this.setState({rg: e.target.value})
    }

    atualizarCpf(e) {
        this.setState({cpf: e.target.value})
    }

    atualizarDataNascimento(e) {
        this.setState({datanascimento: e.target.value})
    }

    atualizarTelefone(e) {
        this.setState({telefone: e.target.value})
    }

    atualizarLogradouro(e) {
        this.setState({logradouro: e.target.value})
    }

    atualizarNumero(e) {
        this.setState({numero: e.target.value})
    }

    atualizarBairro(e) {
        this.setState({bairro: e.target.value})
    }

    atualizarCidade(e) {
        this.setState({cidade: e.target.value})
    }

    atualizarEstado(e) {
        this.setState({estado: e.target.value})
    }

    atualizarEmail(e) {
        this.setState({email: e.target.value})
    }

    atualizarSenha(e) {
        this.setState({senha: e.target.value})
    }

    atualizarConfirmarSenha(e) {
        this.setState({confirmarsenha: e.target.value})
    }

    atualizarCredencial(e) {
        this.setState({idcredencial: e.target.value})
    }


    
    render() {
        return (
            <div className="fundo-admin">
                <Navbar/>
                <div className="card cadastrar-usuario">
                    <h1>Cadastrar Usuário</h1>
                    <h2>Informações pessoais</h2>
                    <form method="" onSubmit={this.cadastrar.bind(this)}>
                    <input  name="nome"
                                className="input-cadastro" 
                                type="text" 
                                placeholder="Nome Completo" 
                                onChange={this.atualizarNome.bind(this)}
                    />
                    <input  name="rg"
                                className="input-cadastro" 
                                type="text" 
                                placeholder="RG" 
                                onChange={this.atualizarRg.bind(this)}
                    />
                    <input  name="cpf"
                                className="input-cadastro" 
                                type="text" 
                                placeholder="CPF" 
                                onChange={this.atualizarCpf.bind(this)}
                    />
                    <input  name="datanascimento"
                                className="input-cadastro" 
                                type="date" 
                                placeholder="Data de nascimento" 
                                onChange={this.atualizarDataNascimento.bind(this)}
                    />
                    <h2>Contato</h2>
                    <input  name="telefone"
                                className="input-cadastro" 
                                type="text" 
                                placeholder="Telefone"
                                data-mask="(00) 00000-0000"
                                onChange={this.atualizarTelefone.bind(this)}
                    />
                    <h2>Endereço</h2>
                    <input  name="logradouro"
                                className="input-cadastro" 
                                type="text" 
                                placeholder="Rua" 
                                onChange={this.atualizarLogradouro.bind(this)}
                    />
                    <input  name="numero"
                                className="input-cadastro" 
                                type="tel"
                                placeholder="Numero" 
                                onChange={this.atualizarNumero.bind(this)}
                    />
                    <input  name="bairro"
                                className="input-cadastro" 
                                type="text" 
                                placeholder="Bairro" 
                                onChange={this.atualizarBairro.bind(this)}
                    />
                    <input  name="cidade"
                                className="input-cadastro" 
                                type="text" 
                                placeholder="Cidade" 
                                onChange={this.atualizarCidade.bind(this)}
                    />
                    <input  name="estado"
                                className="input-cadastro" 
                                type="text" 
                                placeholder="Estado" 
                                onChange={this.atualizarEstado.bind(this)}
                    />
                    <h2>Informações de login</h2>
                    <input  name="email"
                                className="input-cadastro" 
                                type="text" 
                                placeholder="Email" 
                                onChange={this.atualizarEmail.bind(this)}
                    />
                    <input  name="senha"
                                className="input-cadastro" 
                                type="password" 
                                placeholder="Senha" 
                                onChange={this.atualizarSenha.bind(this)}
                    />
                    <input  name="confirmarsenha"
                                className="input-cadastro" 
                                type="password" 
                                placeholder="Confirmar senha" 
                                onChange={this.atualizarConfirmarSenha.bind(this)}
                    />
                    <select className="select-credencial" name="" id="selecionar-credencial" onChange={this.atualizarCredencial.bind(this)}>
                        <option value="" defaultValue="selected">Selecione</option>
                        <option value="1">Administrador</option>
                        <option value="2">Medico</option>
                        <option value="3">Paciente</option>
                    </select>
                    <br/>
                    <button type="submit" className="botao-cadastrar">Cadastrar</button>
                </form>
                </div>
            </div>
        )
    }
}

export default Admin
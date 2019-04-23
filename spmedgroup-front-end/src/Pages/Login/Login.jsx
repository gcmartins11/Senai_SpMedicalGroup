import React, {Component} from 'react'
import Axios from 'axios'
import {parseJwt} from '../../Services/Auth'
import './Login.css'
import Logo from '../../Img/logo-spmed.png'

class Login extends Component {
    constructor() {
        super();
        this.state = {
            email: '',
            senha: '',
            mensagemErro: ''
        }
    }

    atualizarEstadoEmail(e) {
        this.setState({email: e.target.value})
    }

    atualizarEstadoSenha(e) {
        this.setState({senha: e.target.value})
    }

    efetuarLogin(e) {
        e.preventDefault()

        console.log("Opa")
        // http://localhost:5000/api/login
        // https://spmedgroup.azurewebsites.net/api/login
        Axios.post("https://spmedgroup.azurewebsites.net/api/login", {
           email : this.state.email,
           senha: this.state.senha
        })
        .then(data => {
            if(data.status === 200){
                console.log(data);
                localStorage.setItem("usuario", data.data.token);
                
                //Verifica o tipo de usuário
                console.log(Object.values(parseJwt())[2])
            }
        })
        .catch(erro => {
            this.setState({ erroMensagem : 'Email ou senha inválidos'});
})
    } 

    render() {
        return (
            <div className="login-background">
                <div className="login-box">
                    <form onSubmit={this.efetuarLogin.bind(this)} className="login-form">
                        <img src={Logo} className="imagem" alt="" width="50%"/>
                        <input  name="email"
                                className="input-padrao" 
                                type="text" 
                                placeholder="Email" 
                                value={this.state.email} 
                                onChange={this.atualizarEstadoEmail.bind(this)}/>
                        <input  name="senha"
                                className="input-padrao" 
                                placeholder="Senha" 
                                type="password" 
                                value={this.state.senha} 
                                onChange={this.atualizarEstadoSenha.bind(this)}/>
                                <p className="text__login" style={{ color : 'red'}}>{this.state.erroMensagem}</p>
                        <button type="submit" className="login-button">Fazer Login</button>
                    </form>
                </div>
            </div>
        )
    }
}

export default Login
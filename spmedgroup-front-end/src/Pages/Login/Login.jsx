import React, {Component} from 'react'
import './Login.css'
import Input from '../../Components/Input/Input'
import Button from '../../Components/Button/Button'
import Logo from '../../Img/logo-spmed.png'

class Login extends Component {
    render() {
        return (
            <div className="login-background">
                <div className="login-box">
                    <form action="" className="login-form">
                        <img src={Logo} className="imagem" alt="" width="50%"/>
                        <Input type="text" placeholder="Email"/>
                        <Input type="password" placeholder="Senha"/>
                        <Button valor="Fazer login"/>
                    </form>
                </div>
            </div>
        )
    }
}

export default Login
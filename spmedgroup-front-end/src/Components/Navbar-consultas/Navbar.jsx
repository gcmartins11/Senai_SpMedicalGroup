import React, { Component } from 'react'
import './Navbar.css'

class Navbar extends Component {

    sair() {
        console.log("Saiu")
        this.props.history.push('/some_url')
    }

    render() {
        return (
            <nav className="nav">
                <a href="     " onClick={this.sair.bind(this)}>Sair</a>
                {/* <a href="http://localhost:3000/login" onClick={() => localStorage.removeItem("usuario")}>Sair</a> */}
            </nav>
        )
    }
}

export default Navbar
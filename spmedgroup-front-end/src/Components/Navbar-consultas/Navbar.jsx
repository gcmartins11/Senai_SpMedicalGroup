import React, {Component} from 'react'
import './Navbar.css'

class Navbar extends Component {
    render() {
        return (
            <nav className="nav">
                {/* <marquee behavior="" direction="right"> */}
                    <a href="http://localhost:3000/login" onClick={() => localStorage.removeItem("usuario")}>Sair</a>
                {/* </marquee> */}
            </nav>
        )
    }
}

export default Navbar
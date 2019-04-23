import React, {Component} from 'react'
import './Consultas.css'

import Navbar from '../../Components/Navbar-consultas/Navbar'
import Card from '../../Components/Card-consultas/Card'

class Consultas extends Component {
    render() {
        return (
            <div className="fundo-consultas">
                <Navbar/>
                <div className="fundo-cards">
                    <Card/>
                    <Card/>
                    <Card/>
                    <Card/>
                </div>
            </div>
        )
    }
}

export default Consultas
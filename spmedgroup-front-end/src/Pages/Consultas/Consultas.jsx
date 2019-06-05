import React, { Component } from 'react'
import './Consultas.css'
import { parseJwt } from '../../Services/Auth'

import Navbar from '../../Components/Navbar-consultas/Navbar'
import Card from '../../Components/Card-consultas/Card'

class Consultas extends Component {
    constructor() {
        super();
        this.credencial = Object.values(parseJwt())[2]
        this.carregarDados();
        // this.listarConsultas();

        this.state = {
            listaconsultas: []
        }
    }

    carregarDados() {

        fetch('http://localhost:5000/api/consultas',
            {
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("usuario")
                }
            })
            .then(response => response.json())
            .then(data => this.setState({ listaconsultas: data }))
            .catch(erro => console.log(erro))

    }

    render() {
        console.log(this.state.listaconsultas)

        return (
            <div className="fundo-consultas">
                <Navbar />
                <div id="fundo-cards" className="fundo-cards">
                    {this.state.listaconsultas.map(chave => { return <Card key={chave.id} especialidade={chave.especialidade} medico={chave.nomeMedico} data={chave.dataConsulta} hora={chave.horaConsulta} status={chave.status} /> })}
                    {/* <Card especialidade="Neurologia" medico="Helena" data="10/10/2019" hora="19:00" status="Realizada" /> */}
                </div>
            </div>
        )
    }
}

export default Consultas
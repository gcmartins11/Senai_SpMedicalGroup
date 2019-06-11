import React, { Component } from 'react'
import './Localizacoes.css'
import Navbar from '../../Components/Navbar-consultas/Navbar'
import firebase from '../../Services/firestore'
import api from '../../Services/Api'

export default class LocalizacoesDetalhes extends Component {
    constructor() {
        super()
        this.state = {
            nome: '',
            cep: '',
            endereco: '',
            numero: '',
            especialidades: [],
        }
    }

    componentWillMount() {
        this.buscarClinica()
        this.buscarUsuarios()
    }

    buscarClinica() {
        firebase.firestore().collection("clinicas")
            .where("cep", "==", localStorage.getItem("cep")).get()
            .then((clinicas) => {
                let clinicasArray = []
                clinicas.forEach((clinica) => {
                    clinicasArray.push({
                        id: clinica.id,
                        nome: clinica.data().nome,
                        cep: clinica.data().cep,
                        endereco: clinica.data().endereco,
                        numero: clinica.data().numero,
                        especialidades: clinica.data().especialidades,

                    })
                })
                this.setState({ nome: clinicasArray[0].nome })
                this.setState({ endereco: clinicasArray[0].endereco })
                this.setState({ numero: clinicasArray[0].numero })
                this.setState({ cep: clinicasArray[0].numero })
                this.setState({ especialidades: clinicasArray[0].especialidades })
                
            })
    }

    buscarUsuarios() {
        api.get('/api/usuarios', {
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("usuario")
            }
        }).then(data => console.log(data))
    }

    render() {
        return (
            <div>
                <Navbar />
                <section class="container">
                    <div class="one">
                        <h2>{this.state.nome}</h2>
                        <h3>{this.state.endereco} - {this.state.numero}</h3>
                        <h3 style={{ marginTop: "20px" }}>Atendimentos feitos</h3>
                        <ul style={{ margin: 0 }}>
                            {this.state.especialidades.map(key => {
                            return <li>{key}</li>
                            })}
                        </ul>
                    </div>
                    <div class="two">
                        <center>
                            <iframe title="gmap" id="gmap_canvas-detalhes" src="https://maps.google.com/maps?q=s%C3%A3o%20paulo&t=&z=11&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0">
                            </iframe>
                        </center>
                    </div>
                </section>
            </div>
        )
    }
}
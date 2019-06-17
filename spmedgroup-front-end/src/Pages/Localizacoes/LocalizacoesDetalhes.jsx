import React, { Component } from 'react'
import './Localizacoes.css'
import Navbar from '../../Components/Navbar-consultas/Navbar'
import firebase from '../../Services/firestore'

export default class LocalizacoesDetalhes extends Component {
    constructor() {
        super()
        this.state = {
            nome: '',
            cep: '',
            endereco: '',
            numero: '',
            especialidades: [],
            prontuarios: [],
            cadastroNome: '',
            cadastroIdade: '',
            cadastroLatitude: '',
            cadastroLongitude: '',
            cadastroDiagnostico: '',


        }
    }

    componentWillMount() {
        this.buscarClinica()
        this.buscarProntuarios()
    }

    buscarClinica() {
        firebase.firestore().collection("clinicas")
            .where("cep", "==", localStorage.getItem("cep"))
            .get()
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


    buscarProntuarios() {
        firebase.firestore().collection("pacientes")
            .get()
            .then((pacientes) => {
                let prontuariosArray = []
                pacientes.forEach((paciente) => {
                    prontuariosArray.push({
                        id: paciente.id,
                        nome: paciente.data().nome,
                        idade: paciente.data().idade,
                        latitude: paciente.data().latitude,
                        longitude: paciente.data().longitude,
                        diagnostico: paciente.data().diagnostico
                    })
                })

                this.setState({ prontuarios: prontuariosArray })
            })
    }

    atualizarState(event) {
        this.setState({ [event.target.name]: event.target.value })
    }

    cadastrarProntuario(event) {
        event.preventDefault()

        const paciente = {
            nome: this.state.cadastroNome,
            idade: this.state.cadastroIdade,
            latitude: this.state.cadastroLatitude,
            lognitude: this.state.cadastroLongitude,
            diagnostico: this.state.cadastroDiagnostico,
        }

        firebase.firestore()
            .collection("pacientes")
            .add(paciente)
            .then((result) => { alert('Cadastrado') })

    }

    render() {
        return (
            <div>
                <Navbar history= {this.props.history}/>
                <section class="container">
                    <div class="one">
                        <h2>{this.state.nome}</h2>
                        <h3>{this.state.endereco} - {this.state.numero}</h3>
                        <h3 style={{ marginTop: "10px" }}>Atendimentos feitos</h3>
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

                    <div className="lista-prontuarios">
                        <h1 className="local-titulo">Prontuarios</h1>
                        {this.state.prontuarios.map((paciente) => {
                            return <h3 style={{ marginTop: "10px" }}>Nome: {paciente.nome} | Idade: {paciente.idade} | Latitude: {paciente.latitude} | Longitude: {paciente.longitude} | Diagnóstico: {paciente.diagnostico}</h3>
                        })}
                    </div>

                <div className="cadastro-Prontuarios">
                    <center>
                        <h1 className="local-titulo">Cadastrar prontuario</h1>
                        <form onSubmit={this.cadastrarProntuario.bind(this)}>
                            <input className="input-padrao" name="cadastroNome" onChange={this.atualizarState.bind(this)} placeholder="Nome" type="text" />
                            <input className="input-padrao" name="cadastroIdade" onChange={this.atualizarState.bind(this)} placeholder="Idade" type="text" />
                            <input className="input-padrao" name="cadastroLatitude" onChange={this.atualizarState.bind(this)} placeholder="Latitude" type="text" />
                            <input className="input-padrao" name="cadastroLongitude" onChange={this.atualizarState.bind(this)} placeholder="Longitude" type="text" />
                            <input className="input-padrao" name="cadastroDiagnostico" onChange={this.atualizarState.bind(this)} placeholder="Diagnostico" type="text" />
                            <input className="input-padrao" type="submit" value="Cadastrar prontuario" />
                        </form>
                    </center>
                </div>
            </div>
        )
    }
}
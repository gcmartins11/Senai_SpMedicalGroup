import React, { Component } from 'react'
// import api from '../../Services/Api'
import Navbar from '../../Components/Navbar-consultas/Navbar'
import ElementoLista from '../../Components/Lista-locais/ElementoLista'
import firebase from '../../Services/firestore'
import './Localizacoes.css'

export default class Localizacoes extends Component {
    constructor() {
        super()
        this.state = {
            clinicas: [],
            nome: '',
            cep: '',
            endereco: '',
            numero: '',
            especialidades: ['maçã']
        }
    }

    componentWillMount = async () => {

        firebase.firestore().collection("clinicas")
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
                this.setState({ clinicas: clinicasArray })
            })

    }

    verDetalhes(e) {
        localStorage.setItem("cep", e.target.name)
        this.props.history.push('/admin/localizacoesDetalhes')
    }

    atualizarState(event) {
        this.setState({ [event.target.name]: event.target.value })
    }

    atualizarEspecialidades(event) {
        let especialidadesArray = this.state.especialidades
        for (let index = 0; index < especialidadesArray.length; index++) {
            if (event.target.value === especialidadesArray[index]) {
                especialidadesArray.splice(index)
            }
            else {
                especialidadesArray.push(event.target.name)
            }
            
        }
        this.setState({especialidades: especialidadesArray})
        console.log(especialidadesArray)
    }

    cadastrar(event) {
        event.preventDefault()

    }

    render() {
        return (
            <div>
                <Navbar />

                <center>
                    <div classNames="gmap_canvas">
                        <iframe title="gmap" id="gmap_canvas" src="https://maps.google.com/maps?q=s%C3%A3o%20paulo&t=&z=11&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0">
                        </iframe>
                    </div>
                </center>

                <div className="local-content">
                    <h2 className="local-titulo">Localizações</h2>
                    {this.state.clinicas.map(key => {
                        return <div style={{ display: "flex", width: "100%", borderBottom: '1px solid #14D6B5', marginBottom: "25px" }}>
                            <ElementoLista nome={key.nome} endereco={key.endereco} numero={key.numero} />
                            <button style={{ width: "20%" }} name={key.cep} onClick={this.verDetalhes.bind(this)}>Ver detalhes</button>
                        </div>
                    })
                    }
                </div>
                <div>
                    <h1>Cadastrar Clinica</h1>
                    <form onSubmit={this.cadastrar.bind(this)}>
                        <input name="nome" onChange={this.atualizarState.bind(this)} placeholder="Nome" type="text" />
                        <input name="cep" onChange={this.atualizarState.bind(this)} placeholder="CEP" type="text" />
                        <input name="endereco" onChange={this.atualizarState.bind(this)} placeholder="Endereço" type="text" />
                        <input name="numero" onChange={this.atualizarState.bind(this)} placeholder="Numero" type="text" />
                        <div>
                            <input type="checkbox" id="neurologia" name="neurologia" onChange={this.atualizarEspecialidades.bind(this)} />
                            <label htmlFor="neurologia">Neurologia</label>
                            
                            <input type="checkbox" id="psicologia" name="psicologia" onChange={this.atualizarEspecialidades.bind(this)} />
                            <label htmlFor="psicologia">Psicologia</label>
                            
                            <input type="checkbox" id="pediatria" name="pediatria" onChange={this.atualizarEspecialidades.bind(this)} />
                            <label htmlFor="pediatria">Psediatria</label>
                            
                        </div>
                        <input type="submit" value="Cadastrar" />
                    </form>
                </div>
            </div>
        )
    }
}
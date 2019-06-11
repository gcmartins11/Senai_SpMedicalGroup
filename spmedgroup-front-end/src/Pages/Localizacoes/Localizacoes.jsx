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
            clinicas: []
        }
    }

    componentWillMount = async () => {
        // const res = await api.get('/api/clinicas', {
        //     headers: {
        //         'Authorization': 'Bearer ' + localStorage.getItem("usuario")
        //     }
        // })

        // this.setState({ clinicas: res.data })

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
            this.setState({clinicas: clinicasArray})
        })

    }

    verDetalhes() {
        console.log("CLIQUE")
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
                        console.log(key)
                    return  <ElementoLista nome={key.nome} endereco={key.endereco} numero={key.numero} />
                    })}
                </div>
            </div>
        )
    }
}
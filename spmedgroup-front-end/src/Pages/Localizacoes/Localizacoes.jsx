import React, {Component} from 'react'
import api from '../../Services/Api'
import Navbar from '../../Components/Navbar-consultas/Navbar'
import './Localizacoes.css'

export default class Localizacoes extends Component {
    constructor() {
        super()
        this.clinicas = []
    }

    componentWillMount = async() => {
        const res = await api.get('/api/clinicas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem("usuario")
            }
        })

        this.clinicas = res.data
        this.render()
    }
    
    render() {
        return (
            <div>
                <Navbar/>
                {this.clinicas.map(key => {
                    console.log(key)
                    return <h1>{key.cnpj}</h1>
                })}
            </div>
        )
    }
}
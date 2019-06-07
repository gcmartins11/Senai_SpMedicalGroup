import React, { Component } from 'react'
import './Localizacoes.css'
import Navbar from '../../Components/Navbar-consultas/Navbar'

export default class LocalizacoesDetalhes extends Component {
    render() {
        return (
            <div>
                <Navbar />
                <section class="container">
                    <div class="one">
                        <h2>Localização 1</h2>
                        <h3>Endereço</h3>
                        <h3>Contato</h3>
                        <h3>Atendimentos feitos</h3>
                        <ul>
                            <li>Pediatria</li>
                            <li>Psicologia</li>
                            <li>Neurologia</li>
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
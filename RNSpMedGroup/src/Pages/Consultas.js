import React, {Component} from 'react'
import { StyleSheet, View, TextInput, Button, Text } from 'react-native'

import api from '../Services/Api'

export default class Consultas extends Component {
    constructor(props) {
        super(props)
        this.state = {
            token: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImxpZ2lhQGdtYWlsLmNvbSIsImp0aSI6IjUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJQYWNpZW50ZSIsImV4cCI6MTU1ODAzODY2MywiaXNzIjoiU3BNZWRHcm91cC5XZWJBcGkiLCJhdWQiOiJTcE1lZEdyb3VwLldlYkFwaSJ9.lOjpGz17nqAGeN2-gKN1I4rwhHLIb4Z7pn1HA4mIqgo',
            role: '',
            listaConsultas: []
        }
    }

    _BuscarDados = async () => {
        const resposta = await api.get('/consultas', {
            headers: {
                'Authorization' : 'Bearer ' + (this.state.token)
            }
        })

        const listaConsultas = resposta.data
        console.warn(listaConsultas)
    }

    // componentDidMount(){
    //     this._BuscarDados()
    // }

    render() {
        return (
            <Button
                    title="Request"
                    onPress={this._BuscarDados.bind(this)}
                    color="#000"
                />
        )
    }
}
import React, { Component } from 'react'
import { StyleSheet, View, TextInput, Button, Text } from 'react-native'
import AsyncStorage from '@react-native-community/async-storage';
import api from '../Services/Api'
import { FlatList } from 'react-native-gesture-handler';

export default class Consultas extends Component {
    constructor(props) {
        super(props)
        this.state = {
            token: '',
            role: '',
            listaConsultas: []
        }
    }

    _BuscarDados = async () => {
        const token = await AsyncStorage.getItem('userToken')
        const role = await AsyncStorage.getItem('userCredential')
        this.setState({ token })
        this.setState({ role })
        // console.warn(token)
        // console.warn(role)

        this._FazerRequest()
    }

    _FazerRequest = async () => {
        const resposta = await api.get('/consultas', {
            headers: {
                'Authorization': 'Bearer ' + (this.state.token)
            }
        })

        const listaConsultas = resposta.data
        console.warn(listaConsultas)
    }

    componentDidMount() {
        this._BuscarDados()
    }

    render() {
        return (
            <View style={styles.container}>
                <View>
                    <FlatList
                        data={this.state.listaConsultas}
                        keyExtractor={item => item.id}
                        renderItem={this.renderItem}
                    />
                </View>

            </View>
        )
    }

    renderItem = ({ item }) => (
        <View>
            <Text>Opa</Text>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
    },
})
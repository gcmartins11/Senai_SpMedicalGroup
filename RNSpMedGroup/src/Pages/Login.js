import React, { Component } from 'react'
import { StyleSheet, View, TextInput, ActivityIndicator, Image, TouchableOpacity, StatusBar, Text, Button } from 'react-native'
import AsyncStorage from '@react-native-community/async-storage'
import jwt from 'jwt-decode'
import api from '../Services/Api'
import logo from '../Img/logo.png'

export default class Login extends Component {
    static navigationOptions = {
        header: null
    };

    constructor(props) {
        super(props)
        this.state = {
            email: 'gabriel.cmartins11@gmail.com',
            senha: 'admin',
            loading: false
        }
    }

    _RealizarLogin = async () => {
        this.setState({ loading: true })
        const resposta = await api.post('/login', {
            email: this.state.email,
            senha: this.state.senha
        })

        await AsyncStorage.setItem('userToken', resposta.data.token)
        await AsyncStorage.setItem('userCredential', jwt(resposta.data.token).role)

        if (resposta.data.token !== null) {
            this.props.navigation.navigate("Consultas")
        }
    }

    render() {
        return (
            <View style={styles.container}>
                <StatusBar
                    hidden={false}
                    translucent={true}
                    backgroundColor="#cecece00"
                />

                <Image
                    style={styles.image}
                    source={logo}
                />
                <TextInput
                    style={styles.input}
                    placeholderTextColor={'#fff'}
                    placeholder="Email"
                    onChangeText={email => this.setState({ email })}
                />
                <TextInput
                    style={styles.input}
                    placeholderTextColor={'#fff'}
                    placeholder="Senha"
                    secureTextEntry={true}
                    onChangeText={senha => this.setState({ senha })}
                />
                { this.state.loading ? <ActivityIndicator color='#fff' size={45} style={styles.loading} /> : null }
                <TouchableOpacity
                    style={styles.button}
                    onPress={this._RealizarLogin}
                >
                    <Text style={styles.buttonText} > Fazer Login </Text>
                </TouchableOpacity>
            </View>
        )
    }
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#13C9AA',
    },
    image: {
        width: 159,
        height: 170,
        margin: 20,
        padding: 20,
    },
    input: {
        width: '80%',
        color: '#fff',
        borderBottomColor: '#fff',
        borderBottomWidth: 2,
        marginBottom: 30,
        paddingLeft: 10,
        paddingBottom: 1,
    },
    button: {
        alignItems: 'center',
        justifyContent: 'center',
        backgroundColor: '#00A0A0',
        color: '#fff',
        width: '45%',
        height: 55,
        borderRadius: 10
    },
    buttonText: {
        color: '#fff',
        fontSize: 20,
        fontWeight: '900'
    },
    loading: {
        marginBottom: 30,
    }

})
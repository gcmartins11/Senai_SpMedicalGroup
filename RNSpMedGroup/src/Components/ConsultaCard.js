import React, { Component } from 'react'
import { View, StyleSheet, Text } from 'react-native'
import AsyncStorage from '@react-native-community/async-storage';

class ConsultaCard extends Component {
    constructor(props) {
        super(props);
        this.state = {
            role: ''
        }
    }

    componentWillMount = async() => {
        await this._buscarRole()
    }

    _buscarRole = async () => {
        const role = await AsyncStorage.getItem('userCredential')
        this.setState({ role })
    }

    render() {
        return (
            <View style={styles.card}>
                {this.state.role == 'Paciente' ?
                <View style={styles.campo}>
                    <Text style={styles.titulo}>Especialidade</Text>
                    <Text style={styles.valor}>{this.props.especialidade}</Text>
                </View>
                    : null
                }

                <View style={styles.campo}>
                    {this.state.role == 'Paciente' ? <Text style={styles.titulo}>Doutor(a)</Text> : <Text style={styles.titulo}>Paciente</Text>}
                    {this.state.role == 'Paciente' ? <Text style={styles.valor}>{this.props.medico}</Text> : <Text style={styles.valor}>{this.props.paciente}</Text>}
                </View>

                <View style={styles.dataHora}>
                    <View>
                        <Text style={styles.titulo}>Data</Text>
                        <Text style={styles.valor}>{this.props.data}</Text>
                    </View>

                    <View>
                        <Text style={styles.titulo}>Hora</Text>
                        <Text style={styles.valor}>{this.props.hora}</Text>
                    </View>
                </View>

                <View style={styles.campo}>
                    <Text style={styles.titulo}>Status</Text>
                    <Text style={styles.valor}>{this.props.status}</Text>
                </View>

            </View>
        )
    }
}

const styles = StyleSheet.create({
    card: {
        backgroundColor: '#dedede',
        marginTop: 24,
        width: '90%',
        height: 280,
        borderRadius: 10,
        borderLeftWidth: 8,
        borderLeftColor: '#13C9AA',
        paddingLeft: 30,
        paddingBottom: 20,
        shadowColor: "#000",
        shadowOffset: {
            width: 0,
            height: 5,
        },
        shadowOpacity: 0.36,
        shadowRadius: 6.68,
        elevation: 10,
    },
    dataHora: {
        flexDirection: 'row',
        width: '70%',
        justifyContent: 'space-between',
        marginTop: 18,
    },
    campo: {
        marginTop: 18,
    },
    titulo: {
        fontSize: 15,
    },
    valor: {
        fontSize: 19,
        fontWeight: 'bold'
    }
})

export default ConsultaCard
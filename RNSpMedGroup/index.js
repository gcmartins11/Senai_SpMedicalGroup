/**
 * @format
 */

import {AppRegistry} from 'react-native';
// import App from './App';
import {name as appName} from './app.json';
import Login from './src/Pages/Login'
import Consultas from './src/Pages/Consultas'
import Navigator from './src'

AppRegistry.registerComponent(appName, () => Navigator);

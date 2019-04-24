import React from 'react'
import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';

import Login from './Login/Login'
import Consultas from './Consultas/Consultas'

export default props =>
<Router>
    <Switch>
        <Route exact path="/login" component={Login}/>
        <Route path="/Consultas" component={Consultas}/>
        <Redirect from="*" to="/login"/>
    </Switch>
</Router>
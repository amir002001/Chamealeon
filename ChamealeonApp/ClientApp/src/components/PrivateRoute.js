import { Route, Redirect } from 'react-router';


const PrivateRoute = ({ component: Component, authHook, ...rest }) => {
    const [auth, setAuth] = authHook

    return (
        <Route {...rest} render={props => (
            auth ?
                <Component {...props} />
                : <Redirect to="/Login" />
        )
        } />
    );
};

export default PrivateRoute
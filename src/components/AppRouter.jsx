import React, {useContext} from 'react';
import {Navigate, Route, Routes} from "react-router-dom";
import {privateRoutes, publicRoutes} from "../router";
import {AuthContext} from "../context";
import Loader from "./UI/Loader/Loader";
import Main from "../pages/Main";
import Store from "../pages/Store";

const AppRouter = () => {
    const {isAuth, isLoading} = useContext(AuthContext);
    console.log(isAuth)


    if (isLoading) {
        return <Loader/>
    }
    //<Navigate to='/posts'/>
    return (
        isAuth
            ?
            <Routes>
                <Route path="/">
                    <Route index element={<Main/>} />
                    <Route path="/technic" element={<Store isTechnic={true}/>} />
                    <Route path="/premium_currency" element={<Store isPremiumCurrency={true}/>}/>
                    <Route path="/premium_account" element={<Store isPremiumAccount={true}/>}/>
                </Route>
            </Routes>
            :
            <Routes>
                <Route path="/">
                    <Route index element={<Main/>} />
                    <Route path="/technic" element={<Store isTechnic={true}/>} />
                    <Route path="/premium_currency" element={<Store isPremiumCurrency={true}/>}/>
                    <Route path="/premium_account" element={<Store isPremiumAccount={true}/>}/>
                </Route>
            </Routes>
    );
    // <Navigate to='/login'/>
};

export default AppRouter;

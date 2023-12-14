import React, {useEffect, useState} from 'react';
import Background from "../components/UI/Background/Background";
import Menu from "../components/UI/Menu/Menu";
import MenuItem from "../components/UI/MenuItem/MenuItem";
import Nav from "../components/UI/Nav/Nav";
import NavItem from "../components/UI/NavItem/NavItem";
import Section from "../components/UI/Section/Section";
import ListWidget from "../components/UI/ListWidget/ListWidget";
import Widget from "../components/UI/Widget/Widget";
import LoginModal from "../components/UI/LoginModal/LoginModal";
import LoginForm from "../components/UI/LoginForm/LoginForm";
import {useFetching} from "../hooks/useFetching";
import PostService from "../API/PostService";
import {getPageCount} from "../utils/pages";
import BackService from "../API/BackService";

const Main = () => {
    const [modalLogin, setModalLogin] = useState(false)
    const [modalCreateUser, setModalCreateUser] = useState(false)

    const [categories, setCategories] = useState([])

    const [fetchCategories, isPostsLoading, postError] = useFetching(async () => {
        const response = await BackService.getCategory();
        setCategories([...categories, ...response.data])
    })

    useEffect(() => {
        fetchCategories()
        console.log(categories)
    }, []);

    function loginUser(userData) {
        console.log(userData)

        setModalLogin(false)
    }

    return (
        <div style={{
            display: "flex",
            width: "100%",
            flexDirection: 'column',
            alignItems: 'center',
        }}>
            <Background></Background>

            <Menu>
                <MenuItem>
                    L
                </MenuItem>
                <MenuItem>
                    Игры
                </MenuItem>
                <MenuItem>
                    Магазин
                </MenuItem>
                <MenuItem style={{marginRight: "auto"}}>
                    Поддержка
                </MenuItem>

                <MenuItem
                    onClick={() => setModalLogin(true)}
                    style={{color: "#ffe8aa"}}
                >
                    Войти
                </MenuItem>
                <MenuItem>
                    Ru
                </MenuItem>
            </Menu>

            <LoginModal visible={modalLogin} setVisible={setModalLogin}>
                <LoginForm login={loginUser}/>
            </LoginModal>

            <Nav>
                <NavItem>
                    H
                </NavItem>
                <NavItem>
                    Золотые Орлы
                </NavItem>
                <NavItem>
                    Техника
                </NavItem>
                <NavItem>
                    Премиум аккаунт
                </NavItem>
                <NavItem>
                    Саундтрек
                </NavItem>
                <NavItem>
                    Бонус-код
                </NavItem>
            </Nav>

            <Section>
                <div className="main-offer__showcase">
                    <div style={{
                        width: "calc(100% - 390px)",
                        height: "auto",
                    }}>
                        <img
                            src="https://sun9-74.userapi.com/impf/uCU3k-dMZbOli-cvKWbflPx7PYMkQH26TSX0Rw/r1ukcJG6tjc.jpg?size=2560x1440&quality=95&sign=f3d5061e24481a982016ef7487a39ddc&type=album"
                            style={{
                                height: "440px",
                                width: "auto",
                            }}
                        />
                    </div>
                </div>

                <ListWidget>
                    <Widget
                        src="https://static-store.gaijin.net/templates/shop/assets/img/jpg/Categories/wt_packs.jpg"
                        style={{
                            marginBottom: "24px"
                        }}
                    >
                        Техника
                    </Widget>
                    <Widget
                        src="https://static-store.gaijin.net/templates/shop/assets/img/jpg/Categories/wt_golden_eagles.jpg"
                        style={{
                            marginBottom: "0",
                            marginRight: "24px",
                            width: "calc(50% - 12px)",
                        }}
                    >
                        Золотые орлы
                    </Widget>
                    <Widget
                        src="https://static-store.gaijin.net/templates/shop/assets/img/jpg/Categories/wt_premium.jpg"
                        style={{
                            marginBottom: "0",
                            width: "calc(50% - 12px)",
                        }}
                    >
                        Премиум аккаунт
                    </Widget>
                </ListWidget>
            </Section>

        </div>
    );
};

export default Main;
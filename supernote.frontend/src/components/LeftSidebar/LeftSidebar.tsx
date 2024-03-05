import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import ListIcon from '@mui/icons-material/List';
import HomeIcon from '@mui/icons-material/Home';
import CreateIcon from '@mui/icons-material/Create';
import { Divider, ListItemButton, Toolbar } from '@mui/material';
import { Link, useLocation } from 'react-router-dom';




function LeftSidebar() {
    const location = useLocation();

    const menuItems = [
        { text: 'Home', icon: <HomeIcon />, route: '/' },
        { text: 'Notes', icon: <ListIcon />, route: '/notes' },
        { text: 'New Note', icon: <CreateIcon />, route: '/new-note' },
        // ادامه دادن با موارد دیگر
    ];
    return (
        <div>
            <Toolbar />
            <Divider />
            <List>
                {menuItems.map(({ text, icon, route }) => (
                    <ListItem key={text} disablePadding>
                        <ListItemButton component={Link} to={route} selected={route === location.pathname }>
                            <ListItemIcon>{icon}</ListItemIcon>
                            <ListItemText primary={text} />
                        </ListItemButton>
                    </ListItem>
                ))}
            </List>
        </div>
    );
}

export default LeftSidebar;
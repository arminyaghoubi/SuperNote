import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import NoteImage from "../assets/Note.png";
import { Grid, Paper } from '@mui/material';

function HomePage() {
    return (
        <Grid container justifyContent="center" alignItems="center">
            <Grid item xs={12} sm={8} md={4}>
                <Card>
                    <Paper elevation={0}>
                        <img
                            src={NoteImage}
                            alt="Notebook"
                            style={{  borderRadius: '4px 4px 0 0' }}
                        />
                    </Paper>

                    {/* Welcome Message and Description Section */}
                    <CardContent>
                        <Typography variant="h4" gutterBottom>
                            Welcome to the Notes App
                        </Typography>
                        <hr />
                        <Typography variant="body1" paragraph>
                            This is a place to store and manage your notes.
                            <br />
                            Start writing new notes or record important information in your notebook.
                        </Typography>
                    </CardContent>
                </Card>
            </Grid>
        </Grid>
    );
}

export default HomePage;
import {Application, Assets, Sprite, Text} from "pixi.js";

const app = new Application();

(async () => {
    await app.init({
       width: 800,
       height: 600,
       backgroundColor: 0x26707a 
    });
    
    document.body.appendChild(app.canvas);
    
    const scoreText: Text = new Text({
       text: 'Score: 0',
       style: {
           fontSize: 36,
           fill: 0x213756
       }
    });
    
    const texture = await Assets.load('assets/cookie.png');
    
    const cookieSprite: Sprite = new Sprite(texture);
    // const cookieSprite: Sprite = Sprite.from('assets/cookie.png');
    
    cookieSprite.anchor.set(0.5,0.5);
    cookieSprite.eventMode = 'static';
    cookieSprite.x = app.screen.width / 2;
    cookieSprite.y = app.screen.height / 2;

    // console.log(app.screen.x);
    
    cookieSprite.on('pointerdown', increaseScore);
    
    let score = 0;
    
    function increaseScore () {
        score++;
        scoreText.text = `Score: ${score}`;
    }
    
    app.stage.addChild(scoreText);
    app.stage.addChild(cookieSprite);
    
    
})();